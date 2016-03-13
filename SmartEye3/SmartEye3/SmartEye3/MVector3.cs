#region Imports

using System;
using System.Xml.Serialization;			// for various Xml attributes
using System.Globalization;

#endregion

/// <summary>
/// vector of doubles with three components (x,y,z)
/// </summary>
/// <author>Richard Potter BSc(Hons)</author>
/// <created>Jun-04</created>
/// <modified>Feb-07</modified>
/// <version>1.20</version>
/// <Changes>
/// Magnitude is now a property
/// Abs(...) now returns magnitude, Recommend: use magnitude property instead
/// Equality opeartions now have a tolerance (note that greater and less than type operations do not)
/// IsUnit methods also have a tolerence
/// Generic IEquatable and IComparable interfaces implemented
/// IFormattable interface (ToString(format, format provider) implemented
/// Mixed product function implemented
/// </Changes>
[Serializable]
public struct MVector3
    : IComparable, IComparable<MVector3>, IEquatable<MVector3>, IFormattable
{

    #region Class Variables

	/// <summary>
	/// The X component of the vector
	/// </summary>
	private	double	x;

	/// <summary>
	/// The Y component of the vector
	/// </summary>
	private	double	y;
	
	/// <summary>
	/// The Z component of the vector
	/// </summary>
	private	double	z;

    #endregion

	#region Constructors

	/// <summary>
	/// Constructor for the MVector3 class accepting three doubles
	/// </summary>
	/// <param name="x">The new x value for the MVector3</param>
	/// <param name="y">The new y value for the MVector3</param>
	/// <param name="z">The new z value for the MVector3</param>
	/// <implementation>
	/// Uses the mutator properties for the MVector3 components to allow verification of input (if implemented)
	/// This results in the need for pre-initialisation initialisation of the MVector3 components to 0 
	/// Due to the necessity for struct's variables to be set in the constructor before moving control
	/// </implementation>
	public MVector3(double x, double y, double z)
	{
		// Pre-initialisation initialisation
		// Implemented because a struct's variables always have to be set in the constructor before moving control
		this.x = 0;
		this.y = 0;
		this.z = 0;

		// Initialisation
		X = x;
		Y = y;
		Z = z;
	}

	/// <summary>
	/// Constructor for the MVector3 class from an array
	/// </summary>
	/// <param name="xyz">Array representing the new values for the MVector3</param>
	/// <implementation>
	/// Uses the VectorArray property to avoid validation code duplication 
	/// </implementation>
	public MVector3(double[] xyz)
	{
		// Pre-initialisation initialisation
		// Implemented because a struct's variables always have to be set in the constructor before moving control
		this.x = 0;
		this.y = 0;
		this.z = 0;

		// Initialisation
		Array = xyz;
	}

	/// <summary>
	/// Constructor for the MVector3 class from another MVector3 object
	/// </summary>
	/// <param name="v1">MVector3 representing the new values for the MVector3</param>
	/// <implementation>
	/// Copies values from MVector3 v1 to this vector, does not hold a reference to object v1 
	/// </implementation>
	public MVector3(MVector3 v1)
	{
		// Pre-initialisation initialisation
		// Implemented because a struct's variables always have to be set in the constructor before moving control
		this.x = 0;
		this.y = 0;
		this.z = 0;

		// Initialisation
		X = v1.X;
		Y = v1.Y;
		Z = v1.Z;
	}

	#endregion

    #region Accessors & Mutators

    /// <summary>
	/// Property for the x component of the MVector3
	/// </summary>
	public double X
    {
        get{return x;}
		set{x = value;}
    }

    /// <summary>
	/// Property for the y component of the MVector3
	/// </summary>
    public double Y
    {
        get{return y;}
		set{y = value;}
    }

    /// <summary>
	/// Property for the z component of the MVector3
	/// </summary>
    public double Z
    {
        get{return z;}
		set{z = value;}
    }

    /// <summary>
    /// Property for the magnitude (aka. length or absolute value) of the MVector3
    /// </summary>
    public double Magnitude
    {
        get 
        {
            return
            Math.Sqrt ( SumComponentSqrs() );
        }
        set 
        {
            if (value < 0)
            { throw new ArgumentOutOfRangeException("value", value, NEGATIVE_MAGNITUDE); }

            if (this == new MVector3(0, 0, 0))
            { throw new ArgumentException(ORAGIN_VECTOR_MAGNITUDE, "this"); }

            this = this * (value / Magnitude);
        }
    }

	/// <summary>
	/// Property for the MVector3 as an array
	/// </summary>
	/// <exception cref="System.ArgumentException">
	/// Thrown if the array argument does not contain exactly three components 
	/// </exception> 
    [XmlIgnore]
	public double[] Array
	{
		get{return new double[] {x,y,z};}
		set
		{
			if(value.Length == 3)
			{
				x = value[0];
				y = value[1];
				z = value[2];
			}
			else
			{
				throw new ArgumentException(THREE_COMPONENTS);
			}
		}
	}

	/// <summary>
	/// An index accessor 
	/// Mapping index [0] -> X, [1] -> Y and [2] -> Z.
	/// </summary>
	/// <param name="index">The array index referring to a component within the vector (i.e. x, y, z)</param>
	/// <exception cref="System.ArgumentException">
	/// Thrown if the array argument does not contain exactly three components 
	/// </exception>
	public double this[ int index ] 
	{
		get	
		{
			switch (index)
			{
				case 0: {return X; }
				case 1: {return Y; }
				case 2: {return Z; }
				default: throw new ArgumentException(THREE_COMPONENTS, "index");
			}
		}
		set 
		{
			switch (index)
			{
				case 0: {X = value; break;}
				case 1: {Y = value; break;}
				case 2: {Z = value; break;}
				default: throw new ArgumentException(THREE_COMPONENTS, "index");
			}
		}
	}

    #endregion

	#region Operators

    /// <summary>
	/// Addition of two Vectors
	/// </summary>
	/// <param name="v1">MVector3 to be added to </param>
	/// <param name="v2">MVector3 to be added</param>
	/// <returns>MVector3 representing the sum of two Vectors</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static MVector3 operator+(MVector3 v1, MVector3 v2)
	{
		return
        (
        	new MVector3
            	(
                	v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z
                )
        );
	}

	/// <summary>
	/// Subtraction of two Vectors
	/// </summary>
	/// <param name="v1">MVector3 to be subtracted from </param>
	/// <param name="v2">MVector3 to be subtracted</param>
	/// <returns>MVector3 representing the difference of two Vectors</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static MVector3 operator-(MVector3 v1, MVector3 v2 )
	{
		return
        (
        	new MVector3
            	(
                	v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z
                )
        );
	}

	/// <summary>
	/// Product of a MVector3 and a scalar value
	/// </summary>
	/// <param name="v1">MVector3 to be multiplied </param>
	/// <param name="s2">Scalar value to be multiplied by </param>
	/// <returns>MVector3 representing the product of the vector and scalar</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static MVector3 operator*(MVector3 v1, double s2)
	{
		return
        (
        	new MVector3
            (
            	v1.X * s2,
                v1.Y * s2,
                v1.Z * s2
            )
        );
	}

	/// <summary>
	/// Product of a scalar value and a MVector3
	/// </summary>
	/// <param name="s1">Scalar value to be multiplied </param>
	/// <param name="v2">MVector3 to be multiplied by </param>
	/// <returns>MVector3 representing the product of the scalar and MVector3</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
    /// <Implementation>
    /// Using the commutative law 'scalar x vector'='vector x scalar'.
    /// Thus, this function calls 'operator*(MVector3 v1, double s2)'.
    /// This avoids repetition of code.
	/// </Implementation>
	public static MVector3 operator*(double s1, MVector3 v2)
	{
		return v2 * s1;
	}

	/// <summary>
	/// Division of a MVector3 and a scalar value
	/// </summary>
	/// <param name="v1">MVector3 to be divided </param>
	/// <param name="s2">Scalar value to be divided by </param>
	/// <returns>MVector3 representing the division of the vector and scalar</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static MVector3 operator/(MVector3 v1, double s2)
	{
		return
        (
        	new MVector3
            	(
                	v1.X / s2,
                    v1.Y / s2,
                    v1.Z / s2
                )
        );
	}

	/// <summary>
	/// Negation of a MVector3
    /// Invert the direction of the MVector3
    /// Make MVector3 negative (-vector)
	/// </summary>
	/// <param name="v1">MVector3 to be negated  </param>
	/// <returns>Negated vector</returns>
    /// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static MVector3 operator-(MVector3 v1)
	{
		return
        (
			new MVector3
				(
        			- v1.X,
					- v1.Y,
					- v1.Z
				)
        );
	}

    /// <summary>
	/// Reinforcement of a MVector3
    /// Make MVector3 positive (+vector)
	/// </summary>
	/// <param name="v1">MVector3 to be reinforced </param>
	/// <returns>Reinforced vector</returns>
    /// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
    /// <Implementation>
    /// Using the rules of Addition (i.e. '+-x' = '-x' and '++x' = '+x')
    /// This function actually  does nothing but return the argument as given
    /// </Implementation>
	public static MVector3 operator+(MVector3 v1)
	{
		return
        (
			new MVector3
				(
        			+ v1.X,
					+ v1.Y,
					+ v1.Z
				)
        );
	}

	/// <summary>
	/// Compare the magnitude of two Vectors (less than)
	/// </summary>
	/// <param name="v1">MVector3 to be compared </param>
	/// <param name="v2">MVector3 to be compared with</param>
	/// <returns>True if v1 less than v2</returns>
	public static bool operator<(MVector3 v1, MVector3 v2)
	{
        return v1.SumComponentSqrs() < v2.SumComponentSqrs();
	}

	/// <summary>
	/// Compare the magnitude of two Vectors (greater than)
	/// </summary>
	/// <param name="v1">MVector3 to be compared </param>
	/// <param name="v2">MVector3 to be compared with</param>
	/// <returns>True if v1 greater than v2</returns>
	public static bool operator>(MVector3 v1, MVector3 v2)
	{
        return v1.SumComponentSqrs() > v2.SumComponentSqrs();
	}

	/// <summary>
	/// Compare the magnitude of two Vectors (less than or equal to)
	/// </summary>
	/// <param name="v1">MVector3 to be compared </param>
	/// <param name="v2">MVector3 to be compared with</param>
	/// <returns>True if v1 less than or equal to v2</returns>
	public static bool operator<=(MVector3 v1, MVector3 v2)
	{
        return v1.SumComponentSqrs() <= v2.SumComponentSqrs();
	}

	/// <summary>
	/// Compare the magnitude of two Vectors (greater than or equal to)
	/// </summary>
	/// <param name="v1">MVector3 to be compared </param>
	/// <param name="v2">MVector3 to be compared with</param>
	/// <returns>True if v1 greater than or equal to v2</returns>
	public static bool operator>=(MVector3 v1, MVector3 v2)
	{
        return v1.SumComponentSqrs() >= v2.SumComponentSqrs();
	}

	/// <summary>
	/// Compare two Vectors for equality.
    /// Are two Vectors equal.
	/// </summary>
	/// <param name="v1">MVector3 to be compared for equality </param>
    /// <param name="v2">MVector3 to be compared to </param>
	/// <returns>Boolean decision (truth for equality)</returns>
	/// <implementation>
	/// Checks the equality of each pair of components, all pairs must be equal
    /// A tolerence to the equality operator is applied
	/// </implementation>
	public static bool operator==(MVector3 v1, MVector3 v2)
	{
        return
        (
            Math.Abs(v1.X - v2.X) <= EqualityTolerence &&
            Math.Abs(v1.Y - v2.Y) <= EqualityTolerence &&
            Math.Abs(v1.Z - v2.Z) <= EqualityTolerence
        );
	}

	/// <summary>
	/// Negative comparator of two Vectors.
    /// Are two Vectors different.
	/// </summary>
	/// <param name="v1">MVector3 to be compared for in-equality </param>
    /// <param name="v2">MVector3 to be compared to </param>
	/// <returns>Boolean decision (truth for in-equality)</returns>
    /// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	/// <implementation>
	/// Uses the equality operand function for two vectors to prevent code duplication
	/// </implementation>
	public static bool operator!=(MVector3 v1, MVector3 v2)
	{
		return !(v1==v2);
	}

	#endregion

	#region Functions

	/// <summary>
	/// Determine the cross product of two Vectors
	/// Determine the vector product
	/// Determine the normal vector (MVector3 90° to the plane)
	/// </summary>
	/// <param name="v1">The vector to multiply</param>
	/// <param name="v2">The vector to multiply by</param>
	/// <returns>MVector3 representing the cross product of the two vectors</returns>
	/// <implementation>
	/// Cross products are non commutable
	/// </implementation>
	/// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static MVector3 CrossProduct(MVector3 v1, MVector3 v2)
	{
		return
		(
			new MVector3
			(
				v1.Y * v2.Z - v1.Z * v2.Y,
				v1.Z * v2.X - v1.X * v2.Z,
				v1.X * v2.Y - v1.Y * v2.X
			)
		);
	}

	/// <summary>
	/// Determine the cross product of this MVector3 and another
    /// Determine the vector product
	/// Determine the normal vector (MVector3 90° to the plane)
	/// </summary>
	/// <param name="other">The vector to multiply by</param>
	/// <returns>MVector3 representing the cross product of the two vectors</returns>
    /// <implementation>
    /// Uses the CrossProduct function to avoid code duplication
    /// <see cref="CrossProduct(MVector3, MVector3)"/>
    /// </implementation>
	public MVector3 CrossProduct(MVector3 other)
	{
		return CrossProduct(this, other);
	}

	/// <summary>
	/// Determine the dot product of two Vectors
	/// </summary>
	/// <param name="v1">The vector to multiply</param>
	/// <param name="v2">The vector to multiply by</param>
	/// <returns>Scalar representing the dot product of the two vectors</returns>
	/// <implementation>
	/// </implementation>
	/// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public static double DotProduct(MVector3 v1, MVector3 v2)
	{
		return
		(
			v1.X * v2.X +
			v1.Y * v2.Y +
			v1.Z * v2.Z
		);
	}

	/// <summary>
	/// Determine the dot product of this MVector3 and another
	/// </summary>
	/// <param name="other">The vector to multiply by</param>
	/// <returns>Scalar representing the dot product of the two vectors</returns>
    /// <implementation>
    /// <see cref="DotProduct(MVector3)"/>
    /// </implementation>
	public double DotProduct(MVector3 other)
	{
		return DotProduct(this, other);
	}

    /// <summary>
    /// Determine the mixed product of three Vectors
    /// Determine volume (with sign precision) of parallelepiped spanned on given vectors
    /// Determine the scalar triple product of three vectors
    /// </summary>
    /// <param name="v1">The first vector</param>
    /// <param name="v2">The second vector</param>
    /// <param name="v3">The third vector</param>
    /// <returns>Scalar representing the mixed product of the three vectors</returns>
    /// <implementation>
    /// Mixed products are non commutable
    /// <see cref="CrossProduct(MVector3, MVector3)"/>
    /// <see cref="DotProduct(MVector3, MVector3)"/>
    /// </implementation>
    /// <Acknowledgement>This code was provided by Michał Bryłka</Acknowledgement>
    public static double MixedProduct(MVector3 v1, MVector3 v2, MVector3 v3)
    {
         return DotProduct(CrossProduct(v1, v2), v3);
    }

    /// <summary>
    /// Determine the mixed product of three Vectors
    /// Determine volume (with sign precision) of parallelepiped spanned on given vectors
    /// Determine the scalar triple product of three vectors
    /// </summary>
    /// <param name="other_v1">The second vector</param>
    /// <param name="other_v2">The third vector</param>
    /// <returns>Scalar representing the mixed product of the three vectors</returns>
    /// <implementation>
    /// Mixed products are non commutable
    /// <see cref="MixedProduct(MVector3, MVector3, MVector3)"/>
    /// Uses MixedProduct(MVector3, MVector3, MVector3) to avoid code duplication
    /// </implementation>
    public double MixedProduct(MVector3 other_v1, MVector3 other_v2)
    {
        return DotProduct(CrossProduct(this, other_v1), other_v2);
    }

	/// <summary>
	/// Get the normalized vector
	/// Get the unit vector
	/// Scale the MVector3 so that the magnitude is 1
	/// </summary>
	/// <param name="v1">The vector to be normalized</param>
	/// <returns>The normalized MVector3</returns>
	/// <implementation>
	/// Uses the Magnitude function to avoid code duplication 
	/// </implementation>
	/// <exception cref="System.DivideByZeroException">
	/// Thrown when the normalisation of a zero magnitude vector is attempted
	/// </exception>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static MVector3 Normalize(MVector3 v1)
	{
		// Check for divide by zero errors
		if ( v1.Magnitude == 0 ) 
		{
			throw new DivideByZeroException( NORMALIZE_0 );
		}
		else
		{
			// find the inverse of the vectors magnitude
			double inverse = 1 / v1.Magnitude;
			return
			(
				new MVector3
				(
					// multiply each component by the inverse of the magnitude
					v1.X * inverse,
					v1.Y * inverse,
					v1.Z * inverse
				)
			);
		}
	}

	/// <summary>
	/// Get the normalized vector
	/// Get the unit vector
	/// Scale the MVector3 so that the magnitude is 1
	/// </summary>
	/// <returns>The normalized MVector3</returns>
	/// <implementation>
	/// Uses the Magnitude and Normalize function to avoid code duplication 
	/// </implementation>
	/// <exception cref="System.DivideByZeroException">
	/// Thrown when the normalisation of a zero magnitude vector is attempted
	/// </exception>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public void Normalize()
	{
		this = Normalize(this);
	}

	/// <summary>
	/// Take an interpolated value from between two Vectors or an extrapolated value if allowed
	/// </summary>
	/// <param name="v1">The MVector3 to interpolate from (where control ==0)</param>
	/// <param name="v2">The MVector3 to interpolate to (where control ==1)</param>
	/// <param name="control">The interpolated point between the two vectors to retrieve (fraction between 0 and 1), or an extrapolated point if allowed</param>
    /// <param name="allowExtrapolation">True if the control may represent a point not on the vertex between v1 and v2</param>
	/// <returns>The value at an arbitrary distance (interpolation) between two vectors or an extrapolated point on the extended virtex</returns>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// Thrown when the control is not between values of 0 and 1 and extrapolation is not allowed
	/// </exception>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static MVector3 Interpolate(MVector3 v1, MVector3 v2, double control, bool allowExtrapolation)
	{
        if (!allowExtrapolation && (control > 1 || control < 0))
		{
			// Error message includes information about the actual value of the argument
			throw new ArgumentOutOfRangeException
					(
						"control",
						control, 
						INTERPOLATION_RANGE + "\n" + ARGUMENT_VALUE + control
					);
		}
		else
		{
			return 
			(
				new MVector3
				(
					v1.X * (1-control) + v2.X * control,	
					v1.Y * (1-control) + v2.Y * control,	
					v1.Z * (1-control) + v2.Z * control
				)
			);
		}
	}

    /// <summary>
	/// Take an interpolated value from between two Vectors
	/// </summary>
	/// <param name="v1">The MVector3 to interpolate from (where control ==0)</param>
	/// <param name="v2">The MVector3 to interpolate to (where control ==1)</param>
	/// <param name="control">The interpolated point between the two vectors to retrieve (fraction between 0 and 1)</param>
	/// <returns>The value at an arbitrary distance (interpolation) between two vectors</returns>
	/// <implementation>
    /// <see cref="Interpolate(MVector3, MVector3, double, bool)"/>
    /// Uses the Interpolate(MVector3,MVector3,double,bool) method to avoid code duplication
	/// </implementation>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// Thrown when the control is not between values of 0 and 1
	/// </exception>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
    public static MVector3 Interpolate(MVector3 v1, MVector3 v2, double control)
    {
        return Interpolate(v1, v2, control, false);
    }


	/// <summary>
	/// Take an interpolated value from between two Vectors
	/// </summary>
	/// <param name="other">The MVector3 to interpolate to (where control ==1)</param>
	/// <param name="control">The interpolated point between the two vectors to retrieve (fraction between 0 and 1)</param>
	/// <returns>The value at an arbitrary distance (interpolation) between two vectors</returns>
	/// <implementation>
	/// <see cref="Interpolate(MVector3, MVector3, double)"/>
	/// Overload for Interpolate method, finds an interpolated value between this MVector3 and another
	/// Uses the Interpolate(MVector3,MVector3,double) method to avoid code duplication
	/// </implementation>
	public MVector3 Interpolate(MVector3 other, double control)
	{
		return Interpolate(this, other, control);
	}

    /// <summary>
    /// Take an interpolated value from between two Vectors or an extrapolated value if allowed
    /// </summary>
    /// <param name="other">The MVector3 to interpolate to (where control ==1)</param>
    /// <param name="control">The interpolated point between the two vectors to retrieve (fraction between 0 and 1), or an extrapolated point if allowed</param>
    /// <param name="allowExtrapolation">True if the control may represent a point not on the vertex between v1 and v2</param>
    /// <returns>The value at an arbitrary distance (interpolation) between two vectors or an extrapolated point on the extended virtex</returns>
    /// <implementation>
    /// <see cref="Interpolate(MVector3, MVector3, double, bool)"/>
    /// Uses the Interpolate(MVector3,MVector3,double,bool) method to avoid code duplication
    /// </implementation>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// Thrown when the control is not between values of 0 and 1 and extrapolation is not allowed
    /// </exception>
    public MVector3 Interpolate(MVector3 other, double control, bool allowExtrapolation)
    {
        return Interpolate(this, other, control);
    }

	/// <summary>
	/// Find the distance between two Vectors
	/// Pythagoras theorem on two Vectors
	/// </summary>
	/// <param name="v1">The MVector3 to find the distance from </param>
	/// <param name="v2">The MVector3 to find the distance to </param>
	/// <returns>The distance between two Vectors</returns>
	/// <implementation>
	/// </implementation>
	public static double Distance(MVector3 v1, MVector3 v2)
	{
		return 
		(
			Math.Sqrt
			(
				(v1.X - v2.X) * (v1.X - v2.X) +
				(v1.Y - v2.Y) * (v1.Y - v2.Y) +	
				(v1.Z - v2.Z) * (v1.Z - v2.Z) 
			)
		);
	}

	/// <summary>
	/// Find the distance between two Vectors
	/// Pythagoras theorem on two Vectors
	/// </summary>
	/// <param name="other">The MVector3 to find the distance to </param>
	/// <returns>The distance between two Vectors</returns>
	/// <implementation>
	/// <see cref="Distance(MVector3, MVector3)"/>
	/// Overload for Distance method, finds distance between this MVector3 and another
	/// Uses the Distance(MVector3,MVector3) method to avoid code duplication
	/// </implementation>
	public double Distance(MVector3 other)
	{
		return Distance(this, other);
	}

	/// <summary>
	/// Find the angle between two Vectors
	/// </summary>
	/// <param name="v1">The MVector3 to discern the angle from </param>
	/// <param name="v2">The MVector3 to discern the angle to</param>
	/// <returns>The angle between two positional Vectors</returns>
	/// <implementation>
	/// </implementation>
	/// <Acknowledgement>F.Hill, 2001, Computer Graphics using OpenGL, 2ed </Acknowledgement>
	public static double Angle(MVector3 v1, MVector3 v2)
	{
		return 
		(
			Math.Acos
				(
					Normalize(v1).DotProduct(Normalize(v2))
				)
		);
	}

	/// <summary>
	/// Find the angle between this MVector3 and another
	/// </summary>
	/// <param name="other">The MVector3 to discern the angle to</param>
	/// <returns>The angle between two positional Vectors</returns>
	/// <implementation>
	/// <see cref="Angle(MVector3, MVector3)"/>
	/// Uses the Angle(MVector3,MVector3) method to avoid code duplication
	/// </implementation>
	public double Angle(MVector3 other)
	{
		return Angle(this, other);
	}

	/// <summary>
	/// compares the magnitude of two Vectors and returns the greater MVector3
	/// </summary>
	/// <param name="v1">The vector to compare</param>
	/// <param name="v2">The vector to compare with</param>
	/// <returns>
	/// The greater of the two Vectors (based on magnitude)
	/// </returns>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static MVector3 Max(MVector3 v1, MVector3 v2)
	{
		if (v1 >= v2){return v1;}
		return v2;
	}

	/// <summary>
	/// compares the magnitude of two Vectors and returns the greater MVector3
	/// </summary>
	/// <param name="other">The vector to compare with</param>
	/// <returns>
	/// The greater of the two Vectors (based on magnitude)
	/// </returns>
	/// <implementation>
	/// <see cref="Max(MVector3, MVector3)"/>
	/// Uses function Max(MVector3, MVector3) to avoid code duplication
	/// </implementation>
	public MVector3 Max(MVector3 other)
	{
		return Max(this, other);
	}

	/// <summary>
	/// compares the magnitude of two Vectors and returns the lesser MVector3
	/// </summary>
	/// <param name="v1">The vector to compare</param>
	/// <param name="v2">The vector to compare with</param>
	/// <returns>
	/// The lesser of the two Vectors (based on magnitude)
	/// </returns>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static MVector3 Min(MVector3 v1, MVector3 v2)
	{
		if (v1 <= v2){return v1;}
		return v2;
	}

	/// <summary>
	/// Compares the magnitude of two Vectors and returns the greater MVector3
	/// </summary>
	/// <param name="other">The vector to compare with</param>
	/// <returns>
	/// The lesser of the two Vectors (based on magnitude)
	/// </returns>
	/// <implementation>
	/// <see cref="Min(MVector3, MVector3)"/>
	/// Uses function Min(MVector3, MVector3) to avoid code duplication
	/// </implementation>
	public MVector3 Min(MVector3 other)
	{
		return Min(this, other);
	}

	/// <summary>
	/// Rotates a MVector3 around the Y axis
	/// Change the yaw of a MVector3
	/// </summary>
	/// <param name="v1">The MVector3 to be rotated</param>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the Y axis</returns>
	public static MVector3 Yaw(MVector3 v1, double degree)
	{
		double x = ( v1.Z * Math.Sin(degree) ) + ( v1.X * Math.Cos(degree) );
		double y = v1.Y;
		double z = ( v1.Z * Math.Cos(degree) ) - ( v1.X * Math.Sin(degree) );
		return new MVector3(x, y, z);
	}

	/// <summary>
	/// Rotates the MVector3 around the Y axis
	/// Change the yaw of the MVector3
	/// </summary>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the Y axis</returns>
    /// <implementation>
	/// <see cref="Yaw(MVector3, Double)"/>
	/// Uses function Yaw(MVector3, double) to avoid code duplication
	/// </implementation>
	public void Yaw(double degree)
	{
		this = Yaw(this, degree);
	}

	/// <summary>
	/// Rotates a MVector3 around the X axis
	/// Change the pitch of a MVector3
	/// </summary>
	/// <param name="v1">The MVector3 to be rotated</param>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the X axis</returns>
	public static MVector3 Pitch(MVector3 v1, double degree)
	{
		double x = v1.X;
		double y = ( v1.Y * Math.Cos(degree) ) - ( v1.Z * Math.Sin(degree) );
		double z = ( v1.Y * Math.Sin(degree) ) + ( v1.Z * Math.Cos(degree) );
		return new MVector3(x, y, z);
	}

	/// <summary>
	/// Rotates a MVector3 around the X axis
	/// Change the pitch of a MVector3
	/// </summary>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the X axis</returns>
	/// <see cref="Pitch(MVector3, Double)"/>
    /// <implementation>
	/// Uses function Pitch(MVector3, double) to avoid code duplication
	/// </implementation>
	public void Pitch(double degree)
	{
		this = Pitch(this, degree);
	}

	/// <summary>
	/// Rotates a MVector3 around the Z axis
	/// Change the roll of a MVector3
	/// </summary>
	/// <param name="v1">The MVector3 to be rotated</param>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the Z axis</returns>
	public static MVector3 Roll(MVector3 v1, double degree)
	{
		double x = ( v1.X * Math.Cos(degree) ) - ( v1.Y * Math.Sin(degree) );
		double y = ( v1.X * Math.Sin(degree) ) + ( v1.Y * Math.Cos(degree) );
		double z = v1.Z;
		return new MVector3(x, y, z);
	}

	/// <summary>
	/// Rotates a MVector3 around the Z axis
	/// Change the roll of a MVector3
	/// </summary>
	/// <param name="degree">The angle to rotate the MVector3 around in degrees</param>
	/// <returns>MVector3 representing the rotation around the Z axis</returns>
    /// <implementation>
	/// <see cref="Roll(MVector3, Double)"/>
	/// Uses function Roll(MVector3, double) to avoid code duplication
	/// </implementation>
	public void Roll(double degree)
	{
		this = Roll(this, degree);
	}

/*	/// <summary>
	/// Reflect a MVector3 about a given normal
	/// </summary>
	/// <param name="normal">The normal MVector3 to reflect about</param>
	/// <returns>
	/// The reflected MVector3
	/// </returns>
	public MVector3 Reflection(MVector3 normal)
	{
		return 
		(
			(
				this.Normalize() - 
				(
					normal *
					2 *
					this.Normalize().DotProduct(normal)
				)
			) *
			this.Magnitude() *
			this
		);
	}
*/

    /// <summary>
    /// Find the absolute value of a MVector3
    /// Find the magnitude of a MVector3
    /// </summary>
    /// <returns>A MVector3 representing the absolute values of the vector</returns>
    /// <implementation>
    /// An alternative interface to the magnitude property
    /// </implementation>
    public static Double Abs(MVector3 v1)
    {
        return v1.Magnitude;
    }

    /// <summary>
    /// Find the absolute value of a MVector3
    /// Find the magnitude of a MVector3
    /// </summary>
    /// <returns>A MVector3 representing the absolute values of the vector</returns>
    /// <implementation>
    /// An alternative interface to the magnitude property
    /// </implementation>
    public double Abs()
    {
        return this.Magnitude;
    }

    #endregion

    #region Component Operations

    /// <summary>
    /// The sum of a MVector3's components
    /// </summary>
    /// <param name="v1">The vector whose scalar components to sum</param>
    /// <returns>The sum of the Vectors X, Y and Z components</returns>
    public static double SumComponents(MVector3 v1)
    {
        return (v1.X + v1.Y + v1.Z);
    }

    /// <summary>
    /// The sum of this MVector3's components
    /// </summary>
    /// <returns>The sum of the Vectors X, Y and Z components</returns>
    /// <implementation>
    /// <see cref="SumComponents(MVector3)"/>
    /// The Components.SumComponents(MVector3) function has been used to prevent code duplication
    /// </implementation>
    public double SumComponents()
    {
        return SumComponents(this);
    }

    /// <summary>
    /// The sum of a MVector3's squared components
    /// </summary>
    /// <param name="v1">The vector whose scalar components to square and sum</param>
    /// <returns>The sum of the Vectors X^2, Y^2 and Z^2 components</returns>
    public static double SumComponentSqrs(MVector3 v1)
    {
        MVector3 v2 = SqrComponents(v1);
        return v2.SumComponents();
    }

    /// <summary>
    /// The sum of this MVector3's squared components
    /// </summary>
    /// <returns>The sum of the Vectors X^2, Y^2 and Z^2 components</returns>
    /// <implementation>
    /// <see cref="SumComponentSqrs(MVector3)"/>
    /// The Components.SumComponentSqrs(MVector3) function has been used to prevent code duplication
    /// </implementation>
    public double SumComponentSqrs()
    {
        return SumComponentSqrs(this);
    }

    /// <summary>
    /// The individual multiplication to a power of a MVector3's components
    /// </summary>
    /// <param name="v1">The vector whose scalar components to multiply by a power</param>
    /// <param name="power">The power by which to multiply the components</param>
    /// <returns>The multiplied MVector3</returns>
    public static MVector3 PowComponents(MVector3 v1, double power)
    {
        return
        (
            new MVector3
                (
                    Math.Pow(v1.X, power),
                    Math.Pow(v1.Y, power),
                    Math.Pow(v1.Z, power)
                )
        );
    }

    /// <summary>
    /// The individual multiplication to a power of this MVector3's components
    /// </summary>
    /// <param name="power">The power by which to multiply the components</param>
    /// <returns>The multiplied MVector3</returns>
    /// <implementation>
    /// <see cref="PowComponents(MVector3, Double)"/>
    /// The Components.PowComponents(MVector3, double) function has been used to prevent code duplication
    /// </implementation>
    public void PowComponents(double power)
    {
        this = PowComponents(this, power);
    }

    /// <summary>
    /// The individual square root of a MVector3's components
    /// </summary>
    /// <param name="v1">The vector whose scalar components to square root</param>
    /// <returns>The rooted MVector3</returns>
    public static MVector3 SqrtComponents(MVector3 v1)
    {
        return
            (
            new MVector3
                (
                    Math.Sqrt(v1.X),
                    Math.Sqrt(v1.Y),
                    Math.Sqrt(v1.Z)
                )
            );
    }

    /// <summary>
    /// The individual square root of this MVector3's components
    /// </summary>
    /// <returns>The rooted MVector3</returns>
    /// <implementation>
    /// <see cref="SqrtComponents(MVector3)"/>
    /// The Components.SqrtComponents(MVector3) function has been used to prevent code duplication
    /// </implementation>
    public void SqrtComponents()
    {
        this = SqrtComponents(this);
    }

    /// <summary>
    /// The MVector3's components squared
    /// </summary>
    /// <param name="v1">The vector whose scalar components are to square</param>
    /// <returns>The squared MVector3</returns>
    public static MVector3 SqrComponents(MVector3 v1)
    {
        return
            (
            new MVector3
                (
                    v1.X * v1.X,
                    v1.Y * v1.Y,
                    v1.Z * v1.Z
                )
            );
    }

    /// <summary>
    /// The MVector3's components squared
    /// </summary>
    /// <returns>The squared MVector3</returns>
    /// <implementation>
    /// <see cref="SqrtComponents(MVector3)"/>
    /// The Components.SqrComponents(MVector3) function has been used to prevent code duplication
    /// </implementation>
    public void SqrComponents()
    {
        this = SqrtComponents(this);
    }

    #endregion

	#region Standard Functions

    /// <summary>
    /// Textual description of the MVector3
    /// </summary>
    /// <Implementation>
    /// Uses ToString(string, IFormatProvider) to avoid code duplication
    /// </Implementation>
    /// <returns>Text (String) representing the vector</returns>
	public override string ToString()
	{
		return ToString(null, null);
	}

    /// <summary>
    /// Verbose textual description of the MVector3
    /// </summary>
    /// <returns>Text (string) representing the vector</returns>
    public string ToVerbString()
    {
        string output = null;

        if (IsUnitVector()) { output += UNIT_VECTOR; }
        else { output += POSITIONAL_VECTOR; }

        output += string.Format("( x={0}, y={1}, z={2} )", X, Y, Z);
        output += MAGNITUDE + Magnitude;

        return output;
    }

    /// <summary>
    /// Textual description of the MVector3
    /// </summary>
    /// <param name="format">Formatting string: 'x','y','z' or '' followed by standard numeric format string characters valid for a double precision floating point</param>
    /// <param name="formatProvider">The culture specific fromatting provider</param>
    /// <returns>Text (String) representing the vector</returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        // If no format is passed
        if (format == null || format == "") return String.Format("({0}, {1}, {2})", X, Y, Z);

        char firstChar = format[0];
        string remainder = null;

        if (format.Length > 1)
        remainder = format.Substring(1);

        switch (firstChar)
        {
            case 'x': return X.ToString(remainder, formatProvider);
            case 'y': return Y.ToString(remainder, formatProvider);
            case 'z': return Z.ToString(remainder, formatProvider);
            default: 
                return String.Format
                    (
                        "({0}, {1}, {2})",
                        X.ToString(format, formatProvider),
                        Y.ToString(format, formatProvider),
                        Z.ToString(format, formatProvider)
                    );
        }
    }

	/// <summary>
	/// Get the hashcode
	/// </summary>
	/// <returns>Hashcode for the object instance</returns>
	/// <implementation>
	/// Required in order to implement comparator operations (i.e. ==, !=)
	/// </implementation>
	/// <Acknowledgement>This code is adapted from CSOpenGL - Lucas Viñas Livschitz </Acknowledgement>
	public override int	GetHashCode() 
	{
		return	
		(
			(int)((X + Y + Z) % Int32.MaxValue)
		);
	}

	/// <summary>
	/// Comparator
	/// </summary>
	/// <param name="other">The other object (which should be a vector) to compare to</param>
	/// <returns>Truth if two vectors are equal within a tolerence</returns>
	/// <implementation>
	/// Checks if the object argument is a MVector3 object 
	/// Uses the equality operator function to avoid code duplication
	/// Required in order to implement comparator operations (i.e. ==, !=)
	/// </implementation>
	public override bool Equals(object other)
	{
		// Check object other is a MVector3 object
		if(other is MVector3)
		{
			// Convert object to MVector3
			MVector3 otherVector = (MVector3)other;

			// Check for equality
			return  otherVector == this;
		}
		else
		{
			return false;
		}
	}

    /// <summary>
    /// Comparator
    /// </summary>
    /// <param name="other">The other MVector3 to compare to</param>
    /// <returns>Truth if two vectors are equal within a tolerence</returns>
    /// <implementation>
    /// Uses the equality operator function to avoid code duplication
    /// </implementation>
    public bool Equals(MVector3 other)
    {
        return other == this;
    }

    /// <summary>
    /// compares the magnitude of this instance against the magnitude of the supplied vector
    /// </summary>
    /// <param name="other">The vector to compare this instance with</param>
    /// <returns>
    /// -1: The magnitude of this instance is less than the others magnitude
    /// 0: The magnitude of this instance equals the magnitude of the other
    /// 1: The magnitude of this instance is greater than the magnitude of the other
    /// </returns>
    /// <implementation>
    /// Implemented to fulfil the IComparable interface
    /// </implementation>
    /// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
    public int CompareTo(MVector3 other)
    {
        if (this < other)
        {
            return -1;
        }
        else if (this > other)
        {
            return 1;
        }
        return 0;
    }

	/// <summary>
	/// compares the magnitude of this instance against the magnitude of the supplied vector
	/// </summary>
	/// <param name="other">The vector to compare this instance with</param>
	/// <returns>
	/// -1: The magnitude of this instance is less than the others magnitude
	/// 0: The magnitude of this instance equals the magnitude of the other
	/// 1: The magnitude of this instance is greater than the magnitude of the other
	/// </returns>
	/// <implementation>
	/// Implemented to fulfil the IComparable interface
	/// </implementation>
	/// <exception cref="ArgumentException">
	/// Throws an exception if the type of object to be compared is not known to this class
	/// </exception>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public	int	CompareTo(object other) 
	{
		if(other is MVector3)
		{
			return CompareTo((MVector3)other);
		}
		else
		{
			// Error condition: other is not a MVector3 object
			throw new ArgumentException
			(
				// Error message includes information about the actual type of the argument
				NON_VECTOR_COMPARISON + "\n" + ARGUMENT_TYPE + other.GetType().ToString(),
				"other"
			);
		}
	}

	#endregion

	#region Decisions

	/// <summary>
	/// Checks if a vector a unit vector
	/// Checks if the MVector3 has been normalized
	/// Checks if a vector has a magnitude of 1
	/// </summary>
	/// <param name="v1">
	/// The vector to be checked for Normalization
	/// </param>
	/// <returns>Truth if the vector is a unit vector</returns>
	/// <implementation>
	/// <see cref="Magnitude"/>	
	/// Uses the Magnitude property in the check to avoid code duplication
    /// Within a tolerence
	/// </implementation>
	public static bool IsUnitVector(MVector3 v1)
	{
        return Math.Abs(v1.Magnitude -1) <= EqualityTolerence;
	}

	/// <summary>
	/// Checks if the vector a unit vector
	/// Checks if the MVector3 has been normalized 
	/// Checks if the vector has a magnitude of 1
	/// </summary>
	/// <returns>Truth if this vector is a unit vector</returns>
	/// <implementation>
	/// <see cref="IsUnitVector(MVector3)"/>	
	/// Uses the isUnitVector(MVector3) property in the check to avoid code duplication
    /// Within a tolerence
	/// </implementation>
	public bool IsUnitVector()
	{
		return IsUnitVector(this);
	}

	/// <summary>
	/// Checks if a face normal vector represents back face
	/// Checks if a face is visible, given the line of sight
	/// </summary>
	/// <param name="normal">
	/// The vector representing the face normal MVector3
	/// </param>
	/// <param name="lineOfSight">
	/// The unit vector representing the direction of sight from a virtual camera
	/// </param>
	/// <returns>Truth if the vector (as a normal) represents a back face</returns>
	/// <implementation>
	/// Uses the DotProduct function in the check to avoid code duplication
	/// </implementation>
	public static bool IsBackFace(MVector3 normal, MVector3 lineOfSight)
	{
        return normal.DotProduct(lineOfSight) < 0;
	}

	/// <summary>
	/// Checks if a face normal vector represents back face
	/// Checks if a face is visible, given the line of sight
	/// </summary>
	/// <param name="lineOfSight">
	/// The unit vector representing the direction of sight from a virtual camera
	/// </param>
	/// <returns>Truth if the vector (as a normal) represents a back face</returns>
	/// <implementation>
	/// <see cref="MVector3.IsBackFace(MVector3, MVector3)"/> 
	/// Uses the isBackFace(MVector3, MVector3) function in the check to avoid code duplication
	/// </implementation>
	public bool IsBackFace(MVector3 lineOfSight)
	{
		return IsBackFace(this, lineOfSight);
	}

	/// <summary>
	/// Checks if two Vectors are perpendicular
	/// Checks if two Vectors are orthogonal
	/// Checks if one MVector3 is the normal of the other
	/// </summary>
	/// <param name="v1">
	/// The vector to be checked for orthogonality
	/// </param>
	/// <param name="v2">
	/// The vector to be checked for orthogonality to
	/// </param>
	/// <returns>Truth if the two Vectors are perpendicular</returns>
	/// <implementation>
	/// Uses the DotProduct function in the check to avoid code duplication
	/// </implementation>
	public static bool IsPerpendicular(MVector3 v1, MVector3 v2)
	{
        return v1.DotProduct(v2) == 0;
	}

	/// <summary>
	/// Checks if two Vectors are perpendicular
	/// Checks if two Vectors are orthogonal
	/// Checks if one MVector3 is the Normal of the other
	/// </summary>
	/// <param name="other">
	/// The vector to be checked for orthogonality
	/// </param>
	/// <returns>Truth if the two Vectors are perpendicular</returns>
	/// <implementation>
	/// Uses the isPerpendicualr(MVector3, MVector3) function in the check to avoid code duplication
	/// </implementation>
	public bool IsPerpendicular(MVector3 other)
	{
		return IsPerpendicular(this, other);
	}

	#endregion

	#region Cartesian Vectors

	/// <summary>
	/// MVector3 representing the Cartesian origin
	/// </summary>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static readonly MVector3 origin = new MVector3(0,0,0);

	/// <summary>
	/// MVector3 representing the Cartesian XAxis
	/// </summary>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static readonly MVector3 xAxis = new MVector3(1,0,0);

	/// <summary>
	/// MVector3 representing the Cartesian YAxis
	/// </summary>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static readonly MVector3 yAxis = new MVector3(0,1,0);

	/// <summary>
	/// MVector3 representing the Cartesian ZAxis
	/// </summary>
	/// <Acknowledgement>This code is adapted from Exocortex - Ben Houston </Acknowledgement>
	public static readonly MVector3 zAxis = new MVector3(0,0,1);

	#endregion

	#region Messages

	/// <summary>
	/// Exception message descriptive text 
	/// Used for a failure for an array argument to have three components when three are needed 
	/// </summary>
	private const string THREE_COMPONENTS = "Array must contain exactly three components , (x,y,z)";

	/// <summary>
	/// Exception message descriptive text 
	/// Used for a divide by zero event caused by the normalization of a vector with magnitude 0 
	/// </summary>
	private const string NORMALIZE_0 = "Can not normalize a vector when it's magnitude is zero";

	/// <summary>
	/// Exception message descriptive text 
	/// Used when interpolation is attempted with a control parameter not between 0 and 1 
	/// </summary>
	private const string INTERPOLATION_RANGE = "Control parameter must be a value between 0 & 1";

	/// <summary>
	/// Exception message descriptive text 
	/// Used when attempting to compare a MVector3 to an object which is not a type of MVector3 
	/// </summary>
	private const string NON_VECTOR_COMPARISON = "Cannot compare a MVector3 to a non-MVector3";

	/// <summary>
	/// Exception message additional information text 
	/// Used when adding type information of the given argument into an error message 
	/// </summary>
	private const string ARGUMENT_TYPE = "The argument provided is a type of ";

	/// <summary>
	/// Exception message additional information text 
	/// Used when adding value information of the given argument into an error message 
	/// </summary>
	private const string ARGUMENT_VALUE = "The argument provided has a value of ";

	/// <summary>
	/// Exception message additional information text 
	/// Used when adding length (number of components in an array) information of the given argument into an error message 
	/// </summary>
	private const string ARGUMENT_LENGTH = "The argument provided has a length of ";

	/// <summary>
	/// Exception message descriptive text 
	/// Used when attempting to set a Vectors magnitude to a negative value 
	/// </summary>
	private const string NEGATIVE_MAGNITUDE = "The magnitude of a MVector3 must be a positive value, (i.e. greater than 0)";

	/// <summary>
	/// Exception message descriptive text 
	/// Used when attempting to set a Vectors magnitude where the MVector3 represents the origin
	/// </summary>
	private const string ORAGIN_VECTOR_MAGNITUDE = "Cannot change the magnitude of MVector3(0,0,0)";

	///////////////////////////////////////////////////////////////////////////////

	private const string UNIT_VECTOR = "Unit vector composing of ";

	private const string POSITIONAL_VECTOR = "Positional vector composing of  ";

	private const string MAGNITUDE = " of magnitude ";

	///////////////////////////////////////////////////////////////////////////////

	#endregion

    #region Constants

    /// <summary>
    /// The tolerence used when determining the equality of two vectors 
    /// </summary>
    public const double EqualityTolerence = Double.Epsilon;

    /// <summary>
    /// The smallest vector possible (based on the double precision floating point structure)
    /// </summary>
    public static readonly MVector3 MinValue = new MVector3(Double.MinValue, Double.MinValue, Double.MinValue);

    /// <summary>
    /// The largest vector possible (based on the double precision floating point structure)
    /// </summary>
    public static readonly MVector3 MaxValue = new MVector3(Double.MaxValue, Double.MaxValue, Double.MaxValue);

    /// <summary>
    /// The smallest positive (non-zero) vector possible (based on the double precision floating point structure)
    /// </summary>
    public static readonly MVector3 Epsilon = new MVector3(Double.Epsilon, Double.Epsilon, Double.Epsilon);

    #endregion
}
