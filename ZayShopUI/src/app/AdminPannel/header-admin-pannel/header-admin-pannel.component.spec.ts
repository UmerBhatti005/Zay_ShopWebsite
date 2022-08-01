import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderAdminPannelComponent } from './header-admin-pannel.component';

describe('HeaderAdminPannelComponent', () => {
  let component: HeaderAdminPannelComponent;
  let fixture: ComponentFixture<HeaderAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeaderAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
