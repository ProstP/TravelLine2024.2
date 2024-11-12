export type LoginUserRequest = {
  login: string;
  password: string;
};

export type RefreshTokenRequest = {
  refreshToken: string;
};

export type RegisterUserRequest = {
  name: string;
  login: string;
  password: string;
};

export type LoginUserResponse = {
  username: string;
  accessToken: string;
  refreshToken: string;
};

export type RefreshTokenResponse = {
  accessToken: string;
  refreshToken: string;
};

export type UserProfileResponse = {
  name: string;
  login: string;
  about: string;
};
