import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LearningComponent } from './learning.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: LearningComponent,
  },
];

@NgModule({
  declarations: [LearningComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
})
export class LearningModule {}
