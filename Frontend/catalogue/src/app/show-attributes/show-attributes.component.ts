import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService, ProductAttribute } from '../categories/categories.service';
import { Guid } from 'guid-typescript';
import { identifierName } from '@angular/compiler';

@Component({
  selector: 'app-show-attributes',
  templateUrl: './show-attributes.component.html',
  styleUrls: ['./show-attributes.component.css']
})
export class ShowAttributesComponent {

  constructor(private activatedRoute : ActivatedRoute, private categoryService : CategoriesService) {}

  attributes : ProductAttribute[] = []
  proId : string = ''
  proName : string = ''
  oldAttribute !: ProductAttribute

  showAddAttribute : boolean = false;
  showModifyAttribute : boolean = false;

  ngOnInit() {
    this.activatedRoute.params.subscribe(parameters => {
      this.proId = parameters['proId']
      this.proName = parameters['proName']
    })

    this.categoryService.getAttributes(this.proId).subscribe(data => {
      this.attributes = data
    })
  }

  EnableAddAttribute() {
    this.showAddAttribute = true;
  }

  EnableModifyAttribute(oldAtt : ProductAttribute) {
    this.showModifyAttribute = true;
    this.oldAttribute = oldAtt;
  }

  DisableAddAttribute() {
    this.showAddAttribute = false;
  }

  DisableModifyAttribute() {
    this.showModifyAttribute = false;
  }

  AddAttribute(ipName : string, ipValue : string) {
    let attId : Guid = Guid.create()
    let att : ProductAttribute = {
      attributeId : attId.toString(),
      name : ipName,
      value : ipValue,
      productId : this.proId
    }
    this.categoryService.addAttribute(att).subscribe(data => {
      if(data != null) {
        alert(`New attribute '${att.name}' got added`)
        this.attributes.push(att)
      }
      else {
        alert('Something went wrong while adding new attribute');
      }
    })
  }

  ModifyAttribute(ipName : string, ipValue : string) {
    let newAtt : ProductAttribute = {
      attributeId : this.oldAttribute.attributeId,
      name : (ipName != null && ipName != '') ? ipName : this.oldAttribute.name,
      value : (ipValue != null && ipValue != '') ? ipValue : this.oldAttribute.value,
      productId : this.proId
    }

    this.categoryService.modifyAttribute(newAtt).subscribe(data => {
      if(data != null) {
        alert(`Attribute '${newAtt.name}' got modified successfully`)
        window.location.reload();
      }
      else{
        alert('Something went wrong while modifying, please try again');
      }
    })
  }

  RemoveAttribute(att : ProductAttribute) {
    this.categoryService.removeAttribute(att).subscribe(data => {
      if(data != null) {
        alert(`Attribute ${att.name} got deleted`)
        let index = this.attributes.indexOf(att)
        this.attributes.splice(index, 1)
      }
      else{
        alert('Something went wrong');
      }
    })
  }
}
