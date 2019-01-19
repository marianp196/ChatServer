import { MyAdressInfo } from './MyAdressInfo';
import { HttpClient } from '@angular/common/http';
import { Adress } from './../chatServices/chatProtokollDtos/Adress';
import { Injectable } from '@angular/core';
import { ReplaySubject, Observable,  } from 'rxjs';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
  constructor(private http: HttpClient) { }

  private CachedMyAdressInfo: MyAdressInfo;

  public GetMyAdress(): Observable<MyAdressInfo> {

    return new Observable<MyAdressInfo>(observer => {
      if (this.CachedMyAdressInfo) {
        observer.next(this.CachedMyAdressInfo);
      } else {
        this.http.get<MyAdressInfo>('http://localhost:50481/api/MyAdressController',
            {withCredentials: true}).subscribe(observer);
      }
      observer.complete();
    });
  }
}
