// <copyright file="CategoryDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;
using FluentValidation;

/// <summary>
/// CategoryDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class CategoryDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryDto"/> class.
    /// </summary>
    public CategoryDto()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryDto"/> class.
    /// </summary>
    /// <param name="category">The category.</param>
    public CategoryDto(Category category)
    {
        this.Id = category.Id;
        this.Name = category.Name;
        this.ChildCategoryIds = category.ChildCategories.Select(x => x.Id).ToList();
        this.ParentCategoryIds = category.ParentCategories.Select(x => x.Id).ToList();
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the child category ids.
    /// </summary>
    /// <value>
    /// The child category ids.
    /// </value>
    public IList<int> ChildCategoryIds { get; set; } = new List<int>();

    /// <summary>
    /// Gets or sets the parent category ids.
    /// </summary>
    /// <value>
    /// The parent category ids.
    /// </value>
    public IList<int> ParentCategoryIds { get; set; } = new List<int>();

    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
        var role = obj as CategoryDto;
        return role != null &&
                this.Id == role.Id &&
                this.Name == role.Name;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    /// </returns>
    public override int GetHashCode()
    {
        var hashCode = -1509228638;
        hashCode = (hashCode * -1521134295) + this.Id.GetHashCode();
        hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Name);
        return hashCode;
    }
}
