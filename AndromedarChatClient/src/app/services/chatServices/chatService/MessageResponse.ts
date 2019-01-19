export class MessageResponse {
  public State: ESendState;
  public ServerId: string;
}

export enum ESendState {
  Success,
  Failed
}
