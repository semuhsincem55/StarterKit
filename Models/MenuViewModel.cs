namespace Starterkit.Models
{
	public class MenuViewModel
	{
		public string Name { get; set; }
		public string? Icon { get; set; }
		public string? Path { get; set; }
		public int Order { get; set; }
		public MenuDto ParentMenu { get; set; }
		public List<RoleDto> Roles { get; set; }
		public List<MenuViewModel>? ChildMenus { get; set; }
	}
	public class MenuDto
	{
		public Guid? Id { get; set; }
		public string MenuName { get; set; }
	}
	public class RoleDto
	{
		public Guid RoleId { get; set; }
		public string RoleName { get; set; }
	}
}
