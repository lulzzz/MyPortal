import {Component, ElementRef, OnDestroy, OnInit, Renderer2} from '@angular/core';
import {PortalViewDirective} from '../../../../shared/portal-view/portal-view.directive';
import {RoleBrowserService} from './role-browser.service';

@Component({
  selector: 'app-role-browser',
  templateUrl: './role-browser.component.html',
  styleUrls: ['./role-browser.component.css']
})
export class RoleBrowserComponent extends PortalViewDirective implements OnInit {

  viewService: RoleBrowserService;

  constructor(protected renderer: Renderer2, protected hostElement: ElementRef, roleBrowserService: RoleBrowserService) {
    super(renderer, hostElement, roleBrowserService);
    this.viewService = roleBrowserService;
  }

  ngOnInit(): void {
  }
}
