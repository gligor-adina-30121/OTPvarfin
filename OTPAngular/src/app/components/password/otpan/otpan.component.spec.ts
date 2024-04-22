import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtpanComponent } from './otpan.component';

describe('OtpanComponent', () => {
  let component: OtpanComponent;
  let fixture: ComponentFixture<OtpanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OtpanComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OtpanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
