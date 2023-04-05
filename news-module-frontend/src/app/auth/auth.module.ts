import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { LoginRegisterGuard } from '../guard/login-register.guard';

const routes: Routes = [
  {
    path: "", children: [
      { path: "", component: LoginComponent },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent }
    ]
    , canActivate: [LoginRegisterGuard]
  }];


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule
  ],
  exports: [
    LoginComponent,
    RegisterComponent
  ]
})
export class AuthModule { }
