import { TestBed } from '@angular/core/testing';

import { DestinazioneServicesService } from './destinazione-services.service';

describe('DestinazioneServicesService', () => {
  let service: DestinazioneServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DestinazioneServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
