import { GameParametersModule } from './game-parameters.module';

describe('FormModule', () => {
    let gameParametersModule: GameParametersModule;

    beforeEach(() => {
        gameParametersModule = new GameParametersModule();
    });

    it('should create an instance', () => {
        expect(GameParametersModule).toBeTruthy();
    });
});
