import GreetingsApp.*; 	// Package containing the stubs
import java.util.Properties;			// Initiating the properties by ORB
import org.omg.PortableServer.POA;		// Portable Server Inheritance Model required for classes
import org.omg.PortableServer.*;
import org.omg.CORBA.*;			// All CORBA applications need to import this package
import org.omg.CosNaming.*; 	// GreetingsServer will make use of the NamingService
import org.omg.CosNaming.NamingContextPackage.*;  	// Package includes exceptions thrown by the service name

class GreetingsImpl extends GreetingsPOA {
	private ORB orb;
	
	// Setting the orb value with the servent. orb value is used to invoke shutdown method
	public void setTheORB(ORB orbValue) {
		orb = orbValue;
	}

	//Implementing the expressGreetings() method below
	public String expressGreetings() {
		return "\nChristmas Greetings !!!\n";
	}

	//Implementing the shutdown() method below
	public void shutdown() {
		orb.shutdown(false);
	}
}
public class GreetingsServer {
	public static void main(String args[]) {
		// Try block below to handle the CORBA system exceptions at run-time
		// Exceptions occur during marshalling, un-marshalling and upcall
		try {
				// Initializing the server local ORB object
				ORB orb = ORB.init(args, null);		// Server command line arguments are passed

				// Referencing to root project object adapter 
				POA root_poa = POAHelper.narrow(orb.resolve_initial_references("TheRootPOA"));

				// Activating POAManager
				root_poa.the_POAManager().activate();
			
				// Creating servent object and registering with ORB
				GreetingsImpl greetingsImpl = new GreetingsImpl();
				greetingsImpl.setTheORB(orb);
						
				// Getting references of object form the servant
				org.omg.CORBA.Object ref = root_poa.servant_to_reference(greetingsImpl);
			
				Greetings greetings_ref = GreetingsHelper.narrow(ref);

				// Getting the  root naming context i.e the object reference for the Servent
				org.omg.CORBA.Object objectReference = orb.resolve_initial_references("NameService");

				// Using NamingContext which is the part of the inter-operable Naming Service (INS) specification
				NamingContextExt namingContextReference = NamingContextExtHelper.narrow(objectReference);

				// Binding the object reference in naming
				String gname = "Greetings";
				NameComponent requiredPath[] = namingContextReference.to_name(gname);
				namingContextReference.rebind(requiredPath, greetings_ref);  	// Binding the servent object with the "Greetings" id

				System.out.println("GreetingsServer ready and waiting for the client object operation invocation...");

				//Waiting for the server object method invocations from the client
				orb.run();

			}
			catch (Exception e) {
				System.err.println("ERROR OCCUREDL :" + e);
				e.printStackTrace(System.out);
			}
			System.out.println("Greetings Server Exiting ....");
	}
}
		
