import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DestinazioneInserisciComponent } from './destinazione-inserisci.component';

describe('DestinazioneInserisciComponent', () => {
  let component: DestinazioneInserisciComponent;
  let fixture: ComponentFixture<DestinazioneInserisciComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DestinazioneInserisciComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DestinazioneInserisciComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
