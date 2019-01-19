import { MyAdressInfo } from './MyAdressInfo';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject, Observable, Subscriber,  } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  constructor(private http: HttpClient) { }

  private CachedMyAdressInfo: MyAdressInfo;

  public GetMyAdress(): Observable<MyAdressInfo> {

    let result = new Observable<MyAdressInfo>(subscrib => {
      if (this.CachedMyAdressInfo) {
        subscrib.next(this.CachedMyAdressInfo);
        subscrib.complete();
      } else {
        this.getAdressInfoFromServer(subscrib);
      }
    });

    return result;
  }

  private getAdressInfoFromServer(observer: Subscriber<MyAdressInfo>) {
    this.http.get<MyAdressInfo>('http://localhost:50481/api/MyAdress', {withCredentials: true})
   .subscribe(adressInfo => {
       this.CachedMyAdressInfo = adressInfo;
        observer.next(adressInfo);
        observer.complete();
    });
  }
}
