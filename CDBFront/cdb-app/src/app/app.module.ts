import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CdbCalculatorComponent } from './components/cdb-calculator/cdb-calculator.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AlertComponent } from './components/utils/alert/alert.component';
import { CalculationResultComponent } from './components/cdb-calculator/calculation-result/calculation-result.component';
import { ResultItemComponent } from './components/cdb-calculator/calculation-result/result-item/result-item.component';

@NgModule({
  declarations: [
    AppComponent,
    CdbCalculatorComponent,
    AlertComponent,
    CalculationResultComponent,
    ResultItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
