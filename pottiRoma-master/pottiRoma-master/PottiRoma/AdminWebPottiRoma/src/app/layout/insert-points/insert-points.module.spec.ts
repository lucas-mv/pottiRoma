import { InsertPointsModule } from './insert-points.module';

describe('FormModule', () => {
    let insertPointsModule: InsertPointsModule;

    beforeEach(() => {
        insertPointsModule = new InsertPointsModule();
    });

    it('should create an instance', () => {
        expect(insertPointsModule).toBeTruthy();
    });
});
