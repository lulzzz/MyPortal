import { AuthService } from './../_services/auth.service';
import { ScriptService } from './../_services/script.service';
import { Component, OnInit } from '@angular/core';
import { SchoolsService } from 'myportal-api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginModel: any = {};

  loginError = '';

  schoolName = '';
  schoolMotto = 'Leap Into Learning';

  constructor(private scriptService: ScriptService, private authService: AuthService, private schoolService: SchoolsService) {  }

  ngOnInit(): void {
    this.scriptService.loadStyleSheet('../../assets/lib/css/pages/login/login-2.css');
    this.schoolService.getLocalSchoolName().subscribe(next => {
      this.schoolName = next;
    });
  }

  login(): void {
    this.authService.login(this.loginModel).subscribe(next => {
      location.reload();
    }, error => {
      console.log(error);
      this.loginError = error.error;
    });
  }

}
