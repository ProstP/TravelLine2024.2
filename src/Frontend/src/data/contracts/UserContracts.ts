export type LoginUserRequest = {
  login: string;
  password: string;
};

export type RegisterUserRequest = {
  name: string;
  login: string;
  password: string;
};

export type UpdateUserRequest = {
  name: string;
  login: string;
  password: string;
  about: string;
};

export type LoginUserResponse = {
  username: string;
  accessToken: string;
  refreshToken: string;
};

export type UserProfileResponse = {
  name: string;
  login: string;
  about: string;
};

export type UpdateUserResponse = {
  accessToken: string;
  refreshToken: string;
};
