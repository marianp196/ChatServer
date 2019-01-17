import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TextMessangerComponent } from './text-messanger.component';

describe('TextMessangerComponent', () => {
  let component: TextMessangerComponent;
  let fixture: ComponentFixture<TextMessangerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TextMessangerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TextMessangerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
