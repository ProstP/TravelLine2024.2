export type RegisterUserRequest = {
  Name: string;
  Login: string;
  Password: string;
};

export type LoginUserRequest = {
  Login: string;
  Password: string;
};

export type RefreshTokenRequest = {
  RefreshToken: string;
};

export type LoginUserResponse = {
  AccessToken: string;
  RefreshToken: string;
};
