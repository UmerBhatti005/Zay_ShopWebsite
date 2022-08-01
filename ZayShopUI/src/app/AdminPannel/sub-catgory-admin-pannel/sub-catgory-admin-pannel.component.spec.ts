import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCatgoryAdminPannelComponent } from './sub-catgory-admin-pannel.component';

describe('SubCatgoryAdminPannelComponent', () => {
  let component: SubCatgoryAdminPannelComponent;
  let fixture: ComponentFixture<SubCatgoryAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubCatgoryAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubCatgoryAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
