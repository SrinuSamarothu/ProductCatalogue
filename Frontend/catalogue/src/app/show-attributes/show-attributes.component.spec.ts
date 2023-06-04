import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowAttributesComponent } from './show-attributes.component';

describe('ShowAttributesComponent', () => {
  let component: ShowAttributesComponent;
  let fixture: ComponentFixture<ShowAttributesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowAttributesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowAttributesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
