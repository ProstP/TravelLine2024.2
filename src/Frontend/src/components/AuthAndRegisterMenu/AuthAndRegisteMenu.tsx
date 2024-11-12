import { useState } from "react";
import PopApMenu from "../PopApMenu/PopApMenu";
import EnterToAccount from "./EnterToAccount/EnterToAccount";
import AuthenticationMenu from "./AuthenticationMenu/AuthenticationMenu";
import RegisterMenu from "./RegisterMenu/RegisterMenu";

type MenuState = "Login" | "Register" | "Enter";

type AuthAndRegisteMenuProps = {
  exit: () => void;
};

const AuthAndRegisterMenu = ({ exit }: AuthAndRegisteMenuProps) => {
  const [state, setState] = useState<MenuState>("Enter");

  return (
    <PopApMenu exit={exit}>
      {state == "Enter" ? (
        <EnterToAccount
          toLogin={() => setState("Login")}
          toRegister={() => setState("Register")}
        ></EnterToAccount>
      ) : null}
      {state == "Login" ? (
        <AuthenticationMenu
          exit={exit}
          toRegister={() => setState("Register")}
        ></AuthenticationMenu>
      ) : null}
      {state == "Register" ? (
        <RegisterMenu
          exit={exit}
          toLogin={() => setState("Login")}
        ></RegisterMenu>
      ) : null}
    </PopApMenu>
  );
};

export default AuthAndRegisterMenu;
