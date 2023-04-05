import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from './models/login-model';
import { Token } from './models/token-model';
import { Observable } from 'rxjs';
import { RegisterModel } from './models/register-model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseURL: string = `${environment.settings.backend}/User`;
  constructor(private http: HttpClient) { 
  }

  login(loginModel: LoginModel) : Observable<Token>{
    var url = `${this.baseURL}/login`
    return this.http.post<Token>(url,loginModel);
  }

  register(registerModel: RegisterModel) : Observable<Token>{
    var url = `${this.baseURL}/register`
    return this.http.post<Token>(url,registerModel);
  }
}
