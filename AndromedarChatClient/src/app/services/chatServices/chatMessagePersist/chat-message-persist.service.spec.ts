import { TestBed } from '@angular/core/testing';

import { ChatMessagePersistService } from './chat-message-persist.service';

describe('ChatMessagePersistService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ChatMessagePersistService = TestBed.get(ChatMessagePersistService);
    expect(service).toBeTruthy();
  });
});
