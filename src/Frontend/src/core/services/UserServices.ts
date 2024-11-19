import {
  LoginUserRequest,
  LoginUserResponse,
  RefreshTokenRequest,
  RefreshTokenResponse,
  RegisterUserRequest,
  UpdateUserRequest,
  UpdateUserResponse,
  UserProfileResponse,
} from "../../data/contracts/UserContracts";
import SendRequest from "./RequestsServices";

const Authenticate = async (data: LoginUserRequest) => {
  const response = await SendRequest<LoginUserRequest, LoginUserResponse>(
    "user/login",
    data,
    "POST"
  );

  if (response.isSuccess && response.value !== null) {
    localStorage.setItem("access-token", response.value.accessToken);
    localStorage.setItem("refresh-token", response.value.refreshToken);
  }

  return response;
};

const Register = async (data: RegisterUserRequest) => {
  const response = await SendRequest<RegisterUserRequest>(
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
  const response = SendRequest<null, UserProfileResponse>(
    "user/profile",
    null,
    "GET",
    true
  );

  return response.then();
};

const Refresh = async (data: RefreshTokenRequest) => {
  const response = await SendRequest<RefreshTokenRequest, RefreshTokenResponse>(
    "user/refresh-token",
    data,
    "POST"
  );

  if (response.isSuccess && response.value !== null) {
    localStorage.setItem("access-token", response.value.accessToken);
    localStorage.setItem("refresh-token", response.value.refreshToken);
  }
};

const Update = async (data: UpdateUserRequest) => {
  const response = await SendRequest<UpdateUserRequest, UpdateUserResponse>(
    "user/update",
    data,
    "PUT",
    true
  );

  if (response.isSuccess && response.value !== null) {
    localStorage.setItem("access-token", response.value.accessToken);
    localStorage.setItem("refresh-token", response.value.refreshToken);
  }

  return response;
};

export { Authenticate, Register, Logout, Profile, Refresh, Update };
