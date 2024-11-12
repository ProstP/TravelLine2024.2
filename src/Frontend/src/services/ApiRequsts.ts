import { SERVER_ADDRESS } from "../data/data";

type Answer<T> = {
  value: T;
  isSuccess: boolean;
};

const ApiRequest = async <RequestType, ResponseType = null>(
  url: string,
  request: RequestType,
  type: "POST" | "GET" | "PUT" | "DELETE",
  isAuth: boolean = false
): Promise<Answer<ResponseType>> => {
  const option: RequestInit = {
    method: type,
    headers: {
      "Content-Type": "application/json",
      Authorization: isAuth
        ? `Bearer ${localStorage.getItem("access-token")}`
        : "",
    },
    body: request === null ? null : JSON.stringify(request),
  };

  let isSuccess = false;

  const response = await fetch(SERVER_ADDRESS + "/api/" + url, option)
    .then((response) => {
      if (!response.ok) {
        throw Error("Response not ok: " + response.statusText);
      }
      isSuccess = true;

      return response.text();
    })
    .then((text) => {
      if (text) {
        return JSON.parse(text);
      } else {
        return null;
      }
    })
    .catch((error) => {
      console.error(error);

      isSuccess = false;
    });

  return {
    value: response,
    isSuccess: isSuccess,
  };
};

export default ApiRequest;