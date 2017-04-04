import ko = require("knockout");
import { LoginItem } from "./LoginItem";

class LoginViewModel {
    public loginModel: LoginItem;

    constructor() {
        this.loginModel = new LoginItem('', '', false);
    }

    public login(): void {
        if (!this.loginForm.valid)
            return;

        this.busy = this.authService
            .login(this.loginModel)
            .subscribe(data => {
                if (data.user) {
                    this.authService.setAuth(data);
                    this.router.navigate(['']);
                }
                if (data.errors)
                    this.errors = data.errors;
            });
    };
}

export = LoginViewModel