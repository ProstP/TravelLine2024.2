import {
  LoginUserRequest,
  LoginUserResponse,
  RefreshTokenRequest,
  RefreshTokenResponse,
  RegisterUserRequest,
  UserProfileResponse,
} from "../data/contracts/UserContracts";
import ApiRequest from "./ApiRequsts";

const Authenticate = async (data: LoginUserRequest) => {
  const response = await ApiRequest<LoginUserRequest, LoginUserResponse>(
    "user/login",
    data,
    "POST"
  );

  if (response.isSuccess) {
    localStorage.setItem("access-token", response.value.accessToken);
    localStorage.setItem("refresh-token", response.value.refreshToken);
  }

  return response;
};

const Register = async (data: RegisterUserRequest) => {
  const response = await ApiRequest<RegisterUserRequest>(
    "user/register",
    data,
    "POST"
  );

  return response;
};

const Logout = () => {
  localStorage.removeItem("access-token");
  localStorage.removeItem("refresh-token");
};

const Profile = () => {
  const response = ApiRequest<null, UserProfileResponse>(
    "user/profile",
    null,
    "GET",
    true
  );

  return response.then();
};

const Refresh = async (data: RefreshTokenRequest) => {
  const response = await ApiRequest<RefreshTokenRequest, RefreshTokenResponse>(
    "user/refresh-token",
    data,
    "POST"
  );

  if (response.isSuccess) {
    localStorage.setItem("access-token", response.value.accessToken);
    localStorage.setItem("refresh-token", response.value.refreshToken);
  }
};

export { Authenticate, Register, Logout, Profile, Refresh };
