import { TestBed } from '@angular/core/testing';

import { ChatModelService } from './chat-model.service';

describe('ChatModelService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ChatModelService = TestBed.get(ChatModelService);
    expect(service).toBeTruthy();
  });
});
