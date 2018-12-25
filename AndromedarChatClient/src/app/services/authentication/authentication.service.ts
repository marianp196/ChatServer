import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public Authenticate(user: string, password: string): Observable<any> {
    let authDto = {
      Name: user,
      Password: password
    };
    return this.http.post('http://localhost:50481/api/auth', authDto, {
      withCredentials: true
    });
  }
}
