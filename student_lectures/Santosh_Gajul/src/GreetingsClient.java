import org.omg.CosNaming.*;  //Naming Service will be used by the GreetingsClient
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;		// This classes are needed by all the CORBA applications
import GreetingsApp.*;

public class GreetingsClient {
	static Greetings greetingsImpl;
	public static void main(String[] args) {
		try{
			// Creating and initializing the ORB object to perform marshaling and IIOP work
			ORB orb = ORB.init(args, null);
			
			// Getting the root object's naming context with the Name Service
			org.omg.CORBA.Object objectreference = orb.resolve_initial_references("NameService");

			// Since this is part of the Inter-operable Naming Service, using the NamingContextExt instead of NamingContext
			NamingContextExt namingcontextreference = NamingContextExtHelper.narrow(objectreference);

			// Object Reference resolution in Naming
			String name = "Greetings";
			greetingsImpl = GreetingsHelper.narrow(namingcontextreference.resolve_str(name));

			System.out.println("Acquired connection on the server object: " + greetingsImpl);
			System.out.println(greetingsImpl.expressGreetings());
			greetingsImpl.shutdown();
		}
		// Handling the CORBA system exceptions at runtime during any of the processes like
		// marshaling, un-marshaling and upcall
		catch (Exception e) {
			System.out.println("ERROR : " + e);
			e.printStackTrace(System.out);
		}
	}
}

