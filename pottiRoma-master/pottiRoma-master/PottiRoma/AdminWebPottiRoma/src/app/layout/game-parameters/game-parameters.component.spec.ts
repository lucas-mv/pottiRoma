import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameParametersComponent } from './game-parameters.component';

describe('GameParametersComponent', () => {
    let component: GameParametersComponent;
    let fixture: ComponentFixture<GameParametersComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
                declarations: [GameParametersComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
        fixture = TestBed.createComponent(GameParametersComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
