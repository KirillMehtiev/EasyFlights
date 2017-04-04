class ChangePasswordModel {
    public oldPassword: string;
    public newPassword: string;
    public newPasswordConfirm: string;

    public constructor(oldPassword:string, newPassword:string, newPasswordConfirm:string) {
        this.oldPassword = oldPassword;
        this.newPassword = newPassword;
        this.newPasswordConfirm = newPasswordConfirm;
    }
}

export = ChangePasswordModel;