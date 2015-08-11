Users = Meteor.users

if (Meteor.isClient) {
}

if (Meteor.isServer) {
	Meteor.startup(function () {
		var uAPI = new Restivus({
			apiPath: "uapi",
			useDefaultAuth: true,
			prettyJson: false
		});

		uAPI.addCollection(Users, {
			excludedEndpoints: ["post", "delete"],
			routeOptions: {
				authRequired: true,
			},
		});
	});
}
