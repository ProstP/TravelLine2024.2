import { SERVER_URI } from "../core/api.config";

type Answer<T> = {
  value: T;
  isSuccess: boolean;
};

const SendRequest = async (url: string, options: RequestInit) => {
  return fetch(SERVER_URI + "/api/" + url, options);
};

type RefreshTokenResponse = {
  accessToken: string;
  refreshToken: string;
};

const RefreshToken = async () => {
  const refreshToken = localStorage.getItem("refresh-token");

  if (refreshToken === null) {
    return false;
  }

  const options: RequestInit = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ refreshToken: refreshToken }),
  };

  const response = await SendRequest("user/refresh-token", options)
    .then((response) => {
      if (response.ok) {
        return response.text();
      } else {
        return null;
      }
    })
    .then((text) => {
      if (text === null) {
        return null;
      } else {
        return JSON.parse(text);
      }
    })
    .catch((error) => console.error(error));

  if (response === null) {
    localStorage.removeItem("access-token");
    localStorage.removeItem("username");
    localStorage.removeItem("refresh-token");

    return false;
  }

  const data = response as RefreshTokenResponse;

  localStorage.setItem("access-token", data.accessToken);
  localStorage.setItem("refresh-token", data.refreshToken);

  return true;
};

const ApiRequest = async <RequestType, ResponseType = null>(
  url: string,
  request: RequestType,
  type: "POST" | "GET" | "PUT" | "DELETE",
  isAuth: boolean = false
): Promise<Answer<ResponseType>> => {
  const options: RequestInit = {
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

  const response = await SendRequest(url, options)
    .then(async (response) => {
      isSuccess = response.ok;

      if (response.status === 401) {
        if (await RefreshToken()) {
          const options: RequestInit = {
            method: type,
            headers: {
              "Content-Type": "application/json",
              Authorization: isAuth
                ? `Bearer ${localStorage.getItem("access-token")}`
                : "",
            },
            body: request === null ? null : JSON.stringify(request),
          };

          return (
            await SendRequest(url, options).then((response) => {
              isSuccess = response.ok;

              return response;
            })
          ).text();
        } else {
          return null;
        }
      }

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
