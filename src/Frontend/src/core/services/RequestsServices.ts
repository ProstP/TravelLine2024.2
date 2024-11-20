import { SERVER_URI } from "../config/api.config";

type Answer<T> = {
  value: T | null;
  isSuccess: boolean;
  message: string;
};

const SendRequest = async <RequestType, ResponseType = null>(
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
  let message: string = "";

  const response = await fetch(SERVER_URI + "/api/" + url, option)
    .then((response) => {
      isSuccess = response.ok;

      return response.text();
    })
    .then((text) => {
      if (text) {
        return JSON.parse(text);
      } else {
        return null;
      }
    })
    .catch(() => {
      message = "Не удаётся подключиться к серверу";

      isSuccess = false;
    });

    let value: ResponseType | null;

    if (isSuccess) {
      value = response;
    }
    else{
      value = null;
      message = response;
    }

  return {
    value: response,
    isSuccess: isSuccess,
    message: message,
  };
};

export default SendRequest;
