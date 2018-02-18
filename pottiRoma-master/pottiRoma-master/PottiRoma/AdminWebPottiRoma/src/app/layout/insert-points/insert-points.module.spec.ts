import { InsertPointsModule } from './insert-points.module';

describe('InsertPointsModule', () => {
    let insertPointsModule: InsertPointsModule;

    beforeEach(() => {
        insertPointsModule = new InsertPointsModule();
    });

    it('should create an instance', () => {
        expect(insertPointsModule).toBeTruthy();
    });
});
