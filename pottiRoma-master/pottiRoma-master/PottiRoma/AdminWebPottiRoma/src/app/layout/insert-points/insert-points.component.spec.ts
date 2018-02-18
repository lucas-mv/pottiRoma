import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertPointsComponent } from './insert-points.component';

describe('InsertPointsComponent', () => {
    let component: InsertPointsComponent;
    let fixture: ComponentFixture<InsertPointsComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
                declarations: [InsertPointsComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
        fixture = TestBed.createComponent(InsertPointsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
