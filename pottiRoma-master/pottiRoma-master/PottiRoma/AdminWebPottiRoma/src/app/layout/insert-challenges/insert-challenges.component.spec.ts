import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertChallengesComponent } from './insert-challenges.component';

describe('InsertChallengesComponent', () => {
    let component: InsertChallengesComponent;
    let fixture: ComponentFixture<InsertChallengesComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
                declarations: [InsertChallengesComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
        fixture = TestBed.createComponent(InsertChallengesComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
