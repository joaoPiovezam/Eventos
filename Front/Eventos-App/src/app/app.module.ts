import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CollapseModule} from 'ngx-bootstrap/collapse';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [],
    imports:    [ 
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        CollapseModule.forRoot(),
        FormsModule
        ],
    providers: [HttpClientModule],

  bootstrap:    []
})
export class AppModule { }