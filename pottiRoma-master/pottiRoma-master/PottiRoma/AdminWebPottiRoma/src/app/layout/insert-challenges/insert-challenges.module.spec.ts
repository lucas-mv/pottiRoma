import { InsertChallengesModule } from './insert-challenges.module';

describe('InsertChallengesModule', () => {
    let insertChallengesModule: InsertChallengesModule;

    beforeEach(() => {
        insertChallengesModule = new InsertChallengesModule();
    });

    it('should create an instance', () => {
        expect(InsertChallengesModule).toBeTruthy();
    });
});
