import { InsertSeasonModule } from './insert-season.module';

describe('InsertSeasonModule', () => {
    let InsertSeasonModule: InsertSeasonModule;

    beforeEach(() => {
        insertSeasonModule = new InsertSeasonModule();
    });

    it('should create an instance', () => {
        expect(InsertSeasonModule).toBeTruthy();
    });
});
