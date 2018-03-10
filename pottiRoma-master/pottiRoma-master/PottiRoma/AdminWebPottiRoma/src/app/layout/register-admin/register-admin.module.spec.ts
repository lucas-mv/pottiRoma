import { RegisterAdminModule } from './register-admin.module';

describe('FormModule', () => {
    let registerAdminModule: RegisterAdminModule;

    beforeEach(() => {
        registerAdminModule = new RegisterAdminModule();
    });

    it('should create an instance', () => {
        expect(RegisterAdminModule).toBeTruthy();
    });
});
