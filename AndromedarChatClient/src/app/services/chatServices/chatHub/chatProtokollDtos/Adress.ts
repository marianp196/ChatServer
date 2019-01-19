import { EAdressType } from './EAdressType';

export class Adress {
  public AdressType: EAdressType;
  public Name: string;
  public Server: string;

  public Equals(adress: Adress): boolean {
    return adress.Name === this.Name && adress.Server === this.Server;
  }
}
