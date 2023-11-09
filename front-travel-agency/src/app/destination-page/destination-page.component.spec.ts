import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinationPageComponent } from './destination-page.component';

describe('DestinationPageComponent', () => {
  let component: DestinationPageComponent;
  let fixture: ComponentFixture<DestinationPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DestinationPageComponent]
    });
    fixture = TestBed.createComponent(DestinationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
