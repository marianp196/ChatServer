import { ChatHubService } from './../services/chatServices/chatHub/chatHub.service';
import { AuthenticationService } from './../services/authentication/authentication.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router,
    private route: ActivatedRoute,
    private authService: AuthenticationService,
    private chatHub: ChatHubService) { }

  public user = '';
  public password = '';

  ngOnInit() {
  }

  public onClick(): void {
    this.authService.Authenticate(this.user, this.password).
      subscribe(() => this.chatHub.Connect('http://localhost:50481/chathub').
        then(() => {
                console.log('loggedin');
                this.router.navigate([this.getReturnUrl()]);
              }));
  }

  public onKeydown(event): void {
    console.log(event.key);
    if (event.key === 'Enter') {
      this.onClick();
    }
  }

  private getReturnUrl(): string {
    return this.route.snapshot.queryParams['returnUrl'] || '/';
  }
}
