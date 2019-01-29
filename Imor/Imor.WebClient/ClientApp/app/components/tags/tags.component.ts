import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
	selector: 'tags',
	templateUrl: './tags.component.html'
})
export class TagsComponent {
	public tags: ImorTag[];

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		http.get(baseUrl + 'api/tags/all').subscribe(result => {

			this.tags = result.json() as ImorTag[];

		}, error => console.error(error));
	}
}

interface ImorTag {
	description: string;
	uri: string;
	label: string;
}
