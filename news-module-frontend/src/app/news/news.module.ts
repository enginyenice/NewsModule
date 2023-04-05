import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { RouterModule, Routes } from '@angular/router';
import { PrivateLayoutComponent } from '../layout/private-layout/private-layout.component';
import { AuthGuard } from '../guard/auth.guard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path:"news",
    component:PrivateLayoutComponent,
    children: [
      {path:"",component:ListComponent},
      {path:"create",component:CreateComponent},
      {path:"update/:id",component:UpdateComponent},
    ],
    canActivate: [AuthGuard]
  }
];

@NgModule({
  declarations: [
    ListComponent,
    CreateComponent,
    UpdateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [RouterModule]
})
export class NewsModule { }
