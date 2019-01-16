import { ChatHubService } from './../services/chatServices/chatHub/chatHub.service';
import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private chatHub: ChatHubService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      //Hier müsste eigentlich nur geprüft werden, ob authentifiziert am Server...
      //Connect könnte an anderer Stelle gemacht werden
        let authenticated = this.chatHub.IsConnected();

        if (! authenticated) {
          this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        }

        return authenticated;
    }
}
