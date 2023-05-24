using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Fiap.Services.Identity
{
    public class SD
    {
		public const string Admin = "Admin";
		public const string Customer = "Customer";

		public static IEnumerable<IdentityResource> IdentityResources =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Email(),
				new IdentityResources.Profile()
			};

		public static IEnumerable<ApiScope> ApiScopes =>
			new List<ApiScope> {
				new ApiScope("fiap", "Fiap Server"),
				new ApiScope(name: "read",   displayName: "Somente leitura."),
				new ApiScope(name: "write",  displayName: "Permite editar."),
				new ApiScope(name: "delete", displayName: "Permite remover.")
			};

		public static IEnumerable<Client> Clients =>
			new List<Client>
			{
				new Client
				{
					ClientId="client",
					ClientSecrets= { new Secret("secret".Sha256())},
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					AllowedScopes={ "read", "write", "profile" }
				},
				new Client
				{
					ClientId="fiap",
					ClientSecrets= { new Secret("secret".Sha256())},
					AllowedGrantTypes = GrantTypes.Code,
					RedirectUris={ "http://localhost:5022/signin-oidc" },
					PostLogoutRedirectUris={"http://localhost:5022/signout-callback-oidc" },
					AllowedScopes=new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						"fiap"
					}
				},
			};
	}
}
