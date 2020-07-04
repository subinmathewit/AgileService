import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintboardComponent } from './sprintboard.component';

describe('SprintboardComponent', () => {
  let component: SprintboardComponent;
  let fixture: ComponentFixture<SprintboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprintboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprintboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
