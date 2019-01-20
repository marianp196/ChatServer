import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TextMessangerContentComponent } from './text-messanger-content.component';

describe('TextMessangerContentComponent', () => {
  let component: TextMessangerContentComponent;
  let fixture: ComponentFixture<TextMessangerContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TextMessangerContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TextMessangerContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
