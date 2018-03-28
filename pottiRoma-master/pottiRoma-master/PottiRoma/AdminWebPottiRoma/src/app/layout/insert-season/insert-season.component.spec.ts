import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertSeasonComponent } from './insert-season.component';

describe('InsertSeasonComponent', () => {
    let component: InsertSeasonComponent;
    let fixture: ComponentFixture<InsertSeasonComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
                declarations: [InsertSeasonComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
        fixture = TestBed.createComponent(InsertSeasonComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
